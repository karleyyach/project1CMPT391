import os
import json

# Define file paths
scriptDirectory = os.path.dirname(os.path.realpath(__file__))
jsonFilePath = os.path.join(scriptDirectory, 'raw data', 'all_semesters.json')
outputFilePath = os.path.join(scriptDirectory, 'queries', 'semester_data.sql')

def readJsonData(filePath):
    with open(filePath, 'r') as file:
        return json.load(file)

def writeSqlQueries(data, filePath):
    with open(filePath, 'w') as file:
        for semester, departments in data.items():
            year, semesterName = semester.split(' ')
            for department, courses in departments.items():
                for course in courses:
                    courseID = course['courseID']
                    for section in course['sections']:
                        sectionID = section['sectionID']
                        capacity = section['capacity']
                        enrolledCount = section['enrolledCount']
                        timeSlotID = section.get('timeSlotID', 'NULL')
                        instructorID = section.get('instructorID', 'TBA') 
                        query = f"INSERT INTO [dbo].[section] ([courseID], [sectionID], [semester], [year], [capacity], [enrolledCount], [instructorID], [timeSlotID]) VALUES ('{courseID}', '{sectionID}', '{semesterName}', '{year}', {capacity}, {enrolledCount}, {instructorID if instructorID != 'NULL' else 'NULL'}, {timeSlotID if timeSlotID != 'NULL' else 'NULL'});\n"
                        file.write(query)

def main():
    jsonData = readJsonData(jsonFilePath)
    writeSqlQueries(jsonData, outputFilePath)

if __name__ == '__main__':
    main()