import os
import json
import random

def loadTimeSlots():
    rawDataDirectory = os.path.join(os.path.dirname(os.path.realpath(__file__)), 'raw data')
    timeSlotsFilePath = os.path.join(rawDataDirectory, 'time_slots.json')

    with open(timeSlotsFilePath, 'r') as jsonFile:
        timeSlots = json.load(jsonFile)
    
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

def assignTimeSlotsToSections(yearlyCourses, morningSlots, afternoonSlots, eveningSlots):
    for semester, subjects in yearlyCourses.items():
        for subject, courses in subjects.items():
            for course in courses:
                availableSlots = morningSlots + afternoonSlots + eveningSlots
                random.shuffle(availableSlots)  # Shuffle to introduce randomness
                for section in course['sections']:
                    for slot in availableSlots:
                        # Ensure each section in the course gets a different time slot
                        if slot['timeSlotID'] not in [sec.get('timeSlotID') for sec in course['sections']]:
                            section['timeSlotID'] = slot['timeSlotID']
                            break

def distributeSlots(weightedSlots, count):
    # Weighted selection: more weights to morning, then afternoon, and least to evening
    return random.choices(weightedSlots, weights=[3, 2, 1], k=count)

def saveCourses(yearlyCourses):
    updatedYearlyCoursesFilePath = os.path.join(os.path.dirname(os.path.realpath(__file__)), 'raw data', 'all_semesters.json')
    with open(updatedYearlyCoursesFilePath, 'w') as outFile:
        json.dump(yearlyCourses, outFile, indent=4)
    print(f"Updated all_semesters.json '{updatedYearlyCoursesFilePath}'.")

if __name__ == "__main__":
    yearlyCoursesFilePath = os.path.join(os.path.dirname(os.path.realpath(__file__)), 'raw data', 'all_semesters.json')
    with open(yearlyCoursesFilePath, 'r') as file:
        yearlyCourses = json.load(file)

    morningSlots, afternoonSlots, eveningSlots = loadTimeSlots()
    assignTimeSlotsToSections(yearlyCourses, morningSlots, afternoonSlots, eveningSlots)
    saveCourses(yearlyCourses)
