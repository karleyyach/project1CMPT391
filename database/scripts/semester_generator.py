import re
import random
import json
import os

subjects = [
    "ACCT", "ACUP", "AEPS", "AGAD", "ANTH", "ARTE", "ASTR", "BCSC", "BICM", "BIOL", 
    "BOTN", "BUSN", "CHEM", "CHIN", "CHME", "CLAS", "CMPT", "CMSK", "COMP", "COOP", 
    "CORR", "COSL", "CRWR", "CYCW", "DESN", "DMWP", "DSLC", "EASC", "ECCS", "ECDV", 
    "ECON", "ECRP", "EDUC", "ENCP", "ENGG", "ENGL", "ENPH", "ENVS", "EOPT", "ERDW", 
    "ESPL", "FNCE", "FOUN", "FREN", "GEND", "GENE", "GERM", "GREK", "HAPR", "HEED", 
    "HIST", "HLSC", "HLST", "HRMT", "HSAD", "HUMN", "INDG", "INFM", "INSE", "INSR", 
    "INTA", "INTB", "INTD", "JAPN", "LATN", "LEGL", "LING", "MARK", "MATH", "MGMT", 
    "MGTS", "MSYS", "MTST", "MUSC", "NEHI", "NURS", "OAAS", "OADM", "OALS", "OAMS", 
    "OCCH", "OOSC", "ORGA", "PABA", "PACT", "PBNS", "PEDS", "PERL", "PESS", "PHIL", 
    "PHSC", "PHSD", "PHYS", "PMGT", "PNRS", "POLS", "PREL", "PROW", "PSSC", "PSYC", 
    "SCIE", "SCMT", "SOCI", "SOST", "SOWK", "SPAN", "STAT", "SUST", "TAST", "THAR", 
    "THAS", "THPR", "TRVL", "URBW", "WINL", "WRIT", "ZOOL"
]

def fetchCourses():
    currentDir = os.path.dirname(__file__)
    filePath = os.path.join(currentDir, 'raw data', 'all_courses.json')
    
    with open(filePath, 'r', encoding='utf-8') as file:
        data = json.load(file)
    
    courses = []
    for subject, courseList in data.items():
        for course in courseList:
            courseID = course['courseID'].strip()
            courses.append(courseID)
    return courses

def categorizeCourses(courses):
    categorized = {}
    for course in courses:
        course = course.replace('\xa0', ' ')
        subjectMatch = re.match(r'\D+', course)
        levelMatch = re.match(r'.*?(\d+)', course)
        
        if subjectMatch and levelMatch:
            subject = subjectMatch.group().strip()
            levelDigit = levelMatch.group(1)[0]  # Take the first digit
            
            if levelDigit == '0':
                continue 
            
            level = int(levelDigit) * 100

            if subject not in categorized:
                categorized[subject] = {100: [], 200: [], 300: [], 400: []}
                
            categorized[subject][level].append(course)
            
    return categorized



def selectCoursesForSemester(categorizedCourses, semester, year, minCourses, maxCourses):
    semesterCourses = {}
    semesterName = f"{semester} {year}"
    
    for subject, levels in categorizedCourses.items():
        allCourses = [course for sublist in levels.values() for course in sublist]
        numCoursesToSelect = random.randint(minCourses, maxCourses)
        selectedCourses = random.sample(allCourses, min(numCoursesToSelect, len(allCourses)))
        semesterCourses[subject] = selectedCourses
        
    return {semesterName: semesterCourses}

def generateYearlyCourses(categorizedCourses, year):
    yearlyCourses = {}
    yearlyCourses.update(selectCoursesForSemester(categorizedCourses, 'Fall', year-1, 5, 12))
    yearlyCourses.update(selectCoursesForSemester(categorizedCourses, 'Winter', year, 5, 12))
    yearlyCourses.update(selectCoursesForSemester(categorizedCourses, 'Spring', year, 2, 4))
    
    return yearlyCourses

def generateSectionsForCourses(yearlyCourses):
    for semester, courses in yearlyCourses.items():
        for subject, courseList in courses.items():
            for i in range(len(courseList)):
                courseCode = courseList[i]
                numSections = random.randint(1, 4)  # 1-4 sections per class
                sections = []
                
                for j in range(numSections):
                    sectionCode = f"AS{str(j+1).zfill(2)}"
                    capacity = random.randint(20, 40)  # Random capacity between 20 and 40
                    enrolledCount = random.randint(1, capacity)  # Random enrolled count up to capacity
                    sections.append({
                        "sectionID": sectionCode,
                        "capacity": capacity,
                        "enrolledCount": enrolledCount
                    })

                courseList[i] = {
                    "courseID": courseCode,
                    "sections": sections
                }
                
    return yearlyCourses

def generateSemestersForYear(categorizedCourses, year):
    yearlyCourses = {}
    yearlyCourses.update(selectCoursesForSemester(categorizedCourses, 'Fall', year-1, 5, 12))
    yearlyCourses.update(selectCoursesForSemester(categorizedCourses, 'Winter', year, 5, 12))
    yearlyCourses.update(selectCoursesForSemester(categorizedCourses, 'Spring', year, 2, 4))
    
    return yearlyCourses

def generate30YearsCourses(categorizedCourses, startYear):
    allCourses = {}
    for year in range(startYear, startYear - 30, -1):  # Iterate backwards through the years
        allCourses.update(generateSemestersForYear(categorizedCourses, year))
    
    return allCourses

def assignTimeSlotsToSections(yearlyCourses, morningSlots, afternoonSlots, eveningSlots):
    usedSlots = set()

    # Each semester
    for semester, subjects in yearlyCourses.items():
        # Each subject
        for subject, courses in subjects.items():
            # Each course
            for course in courses:
                # Each section
                for section in course['sections']:
                    # Each time slot (available)
                    for slotList in [morningSlots, afternoonSlots, eveningSlots]:
                        random.shuffle(slotList)
                        # Each ID
                        for slot in slotList:
                            if slot['timeSlotID'] not in usedSlots:
                                section['timeSlotID'] = slot['timeSlotID']
                                usedSlots.add(slot['timeSlotID'])
                                break
                        if 'timeSlotID' in section:
                            break
    return yearlyCourses

def loadTimeSlots():
    rawDataDirectory = os.path.join(os.path.dirname(os.path.realpath(__file__)), 'raw data')
    timeSlotsFilePath = os.path.join(rawDataDirectory, 'time_slots.json')

    with open(timeSlotsFilePath, 'r') as jsonFile:
        timeSlots = json.load(jsonFile)
    
    # morning, afternoon, and evening
    morningSlots, afternoonSlots, eveningSlots = [], [], []
    for slot in timeSlots:
        startHour = int(slot['startTime'].split(':')[0])
        if startHour < 12:
            morningSlots.append(slot)
        elif startHour < 17:
            afternoonSlots.append(slot)
        else:
            eveningSlots.append(slot)

    return morningSlots, afternoonSlots, eveningSlots

# Main execution
startYear = 2024  # Starting year
courses = fetchCourses()  # Fetch courses from JSON
categorizedCourses = categorizeCourses(courses)  # Categorize fetched courses
allCourses = generate30YearsCourses(categorizedCourses, startYear)  # Generate courses for 30 years
allCoursesWithSections = generateSectionsForCourses(allCourses)  # Generate sections for the courses

morningSlots, afternoonSlots, eveningSlots = loadTimeSlots()
allCoursesWithSections = assignTimeSlotsToSections(allCoursesWithSections, morningSlots, afternoonSlots, eveningSlots) # Assign times to each section

# Output
scriptDirectory = os.path.dirname(os.path.realpath(__file__))
rawDataDirectory = os.path.join(scriptDirectory, 'raw data')
if not os.path.exists(rawDataDirectory):
    os.makedirs(rawDataDirectory)
outputFilePath = os.path.join(rawDataDirectory, 'all_semesters.json')

with open(outputFilePath, 'w') as outFile:
    json.dump(allCoursesWithSections, outFile, indent=4)

print(f"Generated courses and sections with time slots for 30 years!!! Saved to ------> '{outputFilePath}'")