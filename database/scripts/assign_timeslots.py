import os
import json
import random

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

# Load yearly courses
yearlyCoursesFilePath = os.path.join(os.path.dirname(os.path.realpath(__file__)), 'raw data', 'semesters.json')
with open(yearlyCoursesFilePath, 'r') as file:
    yearlyCourses = json.load(file)

# Load time slots
morningSlots, afternoonSlots, eveningSlots = loadTimeSlots()

# Assign time slots to sections
yearlyCoursesWithSlots = assignTimeSlotsToSections(yearlyCourses, morningSlots, afternoonSlots, eveningSlots)

# Save
updatedYearlyCoursesFilePath = os.path.join(os.path.dirname(os.path.realpath(__file__)), 'raw data', 'semesters.json')

with open(updatedYearlyCoursesFilePath, 'w') as outFile:
    json.dump(yearlyCoursesWithSlots, outFile, indent=4)

print(f"Updated semesters.json '{updatedYearlyCoursesFilePath}'.")
