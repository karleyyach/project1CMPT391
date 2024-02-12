from datetime import datetime, time, timedelta
import json
import os

def createTimeSlots():
    timeSlots = []
    timeSlotId = 1
    # Define start times with a weighted distribution towards morning
    startTimesMorning = [time(hour=h) for h in range(8, 12)]  # Every hour from 8AM to 11AM
    startTimesAfternoon = [time(hour=h) for h in range(12, 18, 2)]  # Every two hours from 12PM to 4PM
    startTimesEvening = [time(hour=h) for h in range(18, 20, 2)]  # Every two hours from 6PM to 8PM
    startTimes = startTimesMorning + startTimesAfternoon + startTimesEvening
    durations = {'MWF': timedelta(minutes=50), 'TTh': timedelta(minutes=80), 
                 'MW': timedelta(minutes=80), 'WF': timedelta(minutes=80),
                 'ThSu': timedelta(minutes=80), 'WeSa': timedelta(minutes=80),
                 'Sun' : timedelta(minutes=120)}

    # Define day combinations
    dayCombinations = {
        'MWF': ['Monday', 'Wednesday', 'Friday'],
        'TTh': ['Tuesday', 'Thursday'],
        'MW': ['Monday', 'Wednesday'],
        'WF': ['Wednesday', 'Friday'],
        'ThSu': ['Thursday', 'Sunday'],
        'WeSa': ['Wednesday', 'Saturday'],
        'Sun' : ['Sunday']
    }

    for combination, days in dayCombinations.items():
        for startTime in startTimes:
            endTime = (datetime.combine(datetime.today(), startTime) + durations[combination]).time()
            # Ensure the last class ends by 10 PM
            if endTime <= time(22, 0):
                for day in days:
                    timeSlots.append({
                        'timeSlotID': timeSlotId,
                        'day': day,
                        'startTime': startTime.strftime('%H:%M:%S'),
                        'endTime': endTime.strftime('%H:%M:%S')
                    })
                timeSlotId += 1  # Increment ID after creating slots for one start time

    return timeSlots

# Generate the time slots
timeSlots = createTimeSlots()

# Define the directory to save the file
scriptDirectory = os.path.dirname(os.path.realpath(__file__))
rawDataDirectory = os.path.join(scriptDirectory, 'raw data')

if not os.path.exists(rawDataDirectory):
    os.makedirs(rawDataDirectory)

outputFilePath = os.path.join(rawDataDirectory, 'time_slots.json')

# Output to JSON
with open(outputFilePath, 'w') as outFile:
    json.dump(timeSlots, outFile, indent=4)

print(f"Generated {len(timeSlots)} time slots and saved to '{outputFilePath}'.")
