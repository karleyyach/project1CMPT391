import json
import os

def jsonToSqlInserts(jsonFilePath, outputFilePath):
    # Read the JSON file
    with open(jsonFilePath, 'r') as jsonFile:
        timeSlots = json.load(jsonFile)

    # Open the output file for writing
    with open(outputFilePath, 'w') as sqlFile:
        # Iterate over each time slot and write an INSERT statement for it
        for slot in timeSlots:
            sqlLine = f"INSERT INTO [dbo].[timeSlot] ([timeSlotID], [day], [startTime], [endTime]) VALUES ({slot['timeSlotID']}, '{slot['day']}', '{slot['startTime']}', '{slot['endTime']}');\n"
            sqlFile.write(sqlLine)

    print(f"SQL INSERT statements have been written to '{outputFilePath}'.")

# Define paths
scriptDirectory = os.path.dirname(os.path.realpath(__file__))
jsonFilePath = os.path.join(scriptDirectory, 'raw data', 'time_slots.json')
outputFilePath = os.path.join(scriptDirectory, 'queries', 'time_slot_data.sql')

# Convert JSON to SQL INSERT statements
jsonToSqlInserts(jsonFilePath, outputFilePath)
