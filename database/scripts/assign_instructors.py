import json
import os
import random
import re


def loadInstructors():
    queryFilePath = os.path.join(os.path.dirname(os.path.realpath(__file__)), 'queries', 'instructor_data.sql')
    instructors = []
    with open(queryFilePath, 'r') as file:
        for line in file:
            if line.startswith("INSERT INTO"):
                parts = line.split("VALUES")[1].strip(" ();\n").split(", ")
                instructorId = parts[0]
                firstName = parts[1].strip("'")
                lastName = parts[2].strip("'")
                deptName = parts[3].strip("'")
                instructors.append({
                    "instructorID": instructorId,
                    "name": f"{firstName} {lastName}",
                    "deptName": deptName
                })
    return instructors

def assignInstructors(yearlyCourses, instructors, departmentMapping):
    # Convert list of instructors to a dictionary keyed by department name for easy lookup
    instructorsByDept = {}
    for instructor in instructors:
        deptName = instructor['deptName']
        if deptName not in instructorsByDept:
            instructorsByDept[deptName] = []
        instructorsByDept[deptName].append(instructor)

    # Assign instructors to courses
    for semester, departments in yearlyCourses.items():
        for deptCode, courses in departments.items():
            mappedDeptName = departmentMapping.get(deptCode)
            for course in courses:
                for section in course['sections']:
                    # Try to assign an instructor from the same department first
                    if mappedDeptName in instructorsByDept and instructorsByDept[mappedDeptName]:
                        instructor = random.choice(instructorsByDept[mappedDeptName])
                    else:
                        # Fallback: Assign a random instructor from any department
                        allInstructors = [instructor for sublist in instructorsByDept.values() for instructor in sublist]
                        instructor = random.choice(allInstructors) if allInstructors else None
                    
                    if instructor:
                        section['instructorID'] = instructor['instructorID']
                        section['instructorName'] = instructor['name']

def saveUpdatedCourses(yearlyCourses):
    updatedYearlyCoursesFilePath = os.path.join(os.path.dirname(os.path.realpath(__file__)), 'raw data', 'all_semesters.json')
    with open(updatedYearlyCoursesFilePath, 'w') as outFile:
        json.dump(yearlyCourses, outFile, indent=4)
    print(f"Updated all_semesters.json '{updatedYearlyCoursesFilePath}'.")

if __name__ == "__main__":
    # Load yearly courses
    yearlyCoursesFilePath = os.path.join(os.path.dirname(os.path.realpath(__file__)), 'raw data', 'all_semesters.json')
    with open(yearlyCoursesFilePath, 'r') as file:
        yearlyCourses = json.load(file)

    # Load instructors
    instructors = loadInstructors()

    # Department mapping provided
    departmentMapping = {
        "ACCT": "Department of Accounting and Finance",
        "ACUP": "Department of Allied Health and Human Performance",
        "AEPS": "Department of Anthropology, Economics and Political Science",
        "AGAD": "Department of Arts and Cultural Management",
        "ANTH": "Department of Anthropology, Economics and Political Science",
        "ARTE": "Department of Studio Arts",
        "ASTR": "Department of Physical Sciences",
        "BCSC": "Department of Communication",
        "BICM": "Department of Biological Sciences",
        "BIOL": "Department of Biological Sciences",
        "BOTN": "Department of Biological Sciences",
        "BUSN": "Department of Management and Organizations",
        "CHEM": "Department of Physical Sciences",
        "CHIN": "Department of Humanities",
        "CHME": "Department of Physical Sciences",
        "CLAS": "Department of Humanities",
        "CMPT": "Department of Computer Science",
        "CMSK": "Department of Communication",
        "COMP": "Department of English",
        "COOP": "Department of Allied Health and Human Performance", # Assuming based on context
        "CORR": "Department of Public Safety and Justice Studies",
        "COSL": "Department of Public Safety and Justice Studies", # Assuming based on context
        "CRWR": "Department of English",
        "CYCW": "Department of Child and Youth Care",
        "DESN": "Department of Design",
        "DMWP": "Department of Human Services and Early Learning", # Assuming based on context
        "DSLC": "Department of Disability Studies", # Assuming, may need to adjust
        "EASC": "Department of Earth and Planetary Sciences", # Assuming, may need to adjust
        "ECCS": "Department of Human Services and Early Learning", # Assuming based on context
        "ECDV": "Department of Human Services and Early Learning",
        "ECON": "Department of Anthropology, Economics and Political Science",
        "ECRP": "Department of Public Safety and Justice Studies", # Assuming based on context
        "EDUC": "Department of Education", # Assuming, may need to adjust
        "ENCP": "Department of Engineering, Computer", # Assuming, may need to adjust
        "ENGG": "Department of Engineering, Computer", # Assuming, may need to adjust
        "ENGL": "Department of English",
        "ENPH": "Department of Physical Sciences", # Assuming, may need to adjust
        "ENVS": "Department of Environmental Science", # Assuming, may need to adjust
        "EOPT": "Department of Allied Health and Human Performance", # Assuming based on context
        "ERDW": "Department of Allied Health and Human Performance", # Assuming based on context
        "ESPL": "Department of Allied Health and Human Performance", # Assuming based on context
        "FNCE": "Department of Accounting and Finance",
        "FOUN": "Department of Education", # Assuming, may need to adjust
        "FREN": "Department of Humanities",
        "GEND": "Department of Sociology",
        "GENE": "Department of Biological Sciences",
        "GERM": "Department of Humanities",
        "GREK": "Department of Humanities",
        "HAPR": "Department of Allied Health and Human Performance", # Assuming based on context
        "HEED": "Department of Health Systems and Sustainability", # Assuming based on context
        "HIST": "Department of Humanities",
        "HLSC": "Department of Human Health and Science", # Assuming, may need to adjust
        "HLST": "Department of Health Systems and Sustainability", # Assuming based on context
        "HRMT": "Department of Management and Organizations",
        "HSAD": "Department of Health Systems and Sustainability", # Assuming based on context
        "HUMN": "Department of Humanities",
        "INDG": "Department of Humanities", # Assuming, may need to adjust
        "INFM": "Department of Library & Information Technology", # Assuming, may need to adjust
        "INSE": "Department of Professional Nursing and Allied Health", # Assuming based on context
        "INSR": "Department of Insurance Studies", # Assuming, may need to adjust
        "INTA": "Department of Interdisciplinary Studies", # Assuming, may need to adjust
        "INTB": "Department of International Business, Marketing, Strategy and Law",
        "INTD": "Department of Interdisciplinary Studies", # Assuming, may need to adjust
        "JAPN": "Department of Humanities",
        "LATN": "Department of Humanities",
        "LEGL": "Department of Public Safety and Justice Studies",
        "LING": "Department of Humanities",
        "MARK": "Department of International Business, Marketing, Strategy and Law",
        "MATH": "Department of Mathematics and Statistics",
        "MGMT": "Department of Management and Organizations",
        "MGTS": "Department of Decision Sciences",
        "MSYS": "Department of Decision Sciences",
        "MTST": "Department of Allied Health and Human Performance",  # Assuming based on context
        "MUSC": "Department of Music",
        "NEHI": "Department of Humanities",  # Assuming based on context for Indigenous Studies
        "NURS": "Department of Nursing Practice",
        "OAAS": "Department of Allied Health and Human Performance",  # Assuming based on Office Assistant context
        "OADM": "Department of Allied Health and Human Performance",  # Assuming based on Office Assistant context
        "OALS": "Department of Allied Health and Human Performance",  # Assuming based on Office Assistant context
        "OAMS": "Department of Allied Health and Human Performance",  # Assuming based on Office Assistant context
        "OCCH": "Department of Occupational Health",  # Assuming, may need to adjust
        "OOSC": "Department of Child and Youth Care",  # Assuming based on context
        "ORGA": "Department of Management and Organizations",
        "PABA": "Department of Psychology",
        "PACT": "Department of Physical Activity",  # Assuming, may need to adjust
        "PBNS": "Department of Nursing Practice",
        "PEDS": "Department of Physical Education & Sport",  # Assuming, may need to adjust
        "PERL": "Department of Physical Education & Recreation & Leisure Sports",  # Assuming, may need to adjust
        "PESS": "Department of Physical Education & Sport Studies",  # Assuming, may need to adjust
        "PHIL": "Department of Humanities",
        "PHSC": "Department of Physical Sciences",
        "PHSD": "Department of Physical Education",  # Assuming, may need to adjust
        "PHYS": "Department of Physical Sciences",
        "PMGT": "Department of Property Management",  # Assuming, may need to adjust
        "PNRS": "Department of Psychiatric Nursing",  # Assuming, may need to adjust
        "POLS": "Department of Anthropology, Economics and Political Science",
        "PREL": "Department of Public Relations",  # Assuming, may need to adjust
        "PROW": "Department of Professional Writing",  # Assuming, may need to adjust
        "PSSC": "Department of Police & Investigations",  # Assuming, may need to adjust
        "PSYC": "Department of Psychology",
        "SCIE": "Department of Sciences",  # Assuming, may need to adjust
        "SCMT": "Department of Supply Chain Management",  # Assuming, may need to adjust
        "SOCI": "Department of Sociology",
        "SOST": "Department of Social Studies",  # Assuming, may need to adjust
        "SOWK": "School of Social Work",
        "SPAN": "Department of Humanities",
        "STAT": "Department of Mathematics and Statistics",
        "SUST": "Department of Sustainability",  # Assuming, may need to adjust
        "TAST": "Department of Special Needs Educational Assistant",  # Assuming, may need to adjust
        "THAR": "Department of Theatre",
        "THAS": "Department of Therapist Assistant",  # Assuming, may need to adjust
        "THPR": "Department of Theatre Production",  # Assuming, may need to adjust
        "TRVL": "Department of Travel and Tourism",  # Assuming, may need to adjust
        "URBW": "Department of Urban Wellness",  # Assuming, may need to adjust
        "WINL": "Department of Work Integrated Learning",  # Assuming, may need to adjust
        "WRIT": "Department of Writing",  # Assuming, may need to adjust
        "ZOOL": "Department of Biological Sciences",
    }

    # Assign instructors to courses
    assignInstructors(yearlyCourses, instructors, departmentMapping)

    # Save the updated data
    saveUpdatedCourses(yearlyCourses)