import os
import json
import random
import re

# File paths
scriptDirectory = os.path.dirname(os.path.realpath(__file__))
semesterJsonFilePath = os.path.join(scriptDirectory, 'raw data', 'all_semesters.json')
studentSQLFilePath = os.path.join(scriptDirectory, 'queries', 'students_data.sql')
outputFilePath = os.path.join(scriptDirectory, 'queries', 'takes_data.sql')

# Constants
CREDITS_PER_COURSE = 3
MAX_COURSES_PER_SEMESTER = 5
SEMESTERS_PER_YEAR = 3
MIN_SEMESTERS_TO_COMPLETE = SEMESTERS_PER_YEAR * 4
MAX_SEMESTERS_TO_COMPLETE = SEMESTERS_PER_YEAR * 8

# Load semester data
with open(semesterJsonFilePath, 'r') as file:
    semesterData = json.load(file)

# Function to read student data from SQL file
def loadStudents(filePath):
    students = []
    with open(filePath, 'r') as file:
        for line in file:
            match = re.search(r"VALUES \('(\d+)', '(\w+)', '(\w+)', (\d+)\);", line)
            if match:
                students.append({
                    "studentID": match.group(1),
                    "firstName": match.group(2),
                    "lastName": match.group(3),
                    "creditsCompleted": int(match.group(4))
                })
    return students

def generateTakesQueries(students, semesterData):
    takesQueries = []
    for student in students:
        semestersCompleted = max((student["creditsCompleted"] // CREDITS_PER_COURSE) // MAX_COURSES_PER_SEMESTER, MIN_SEMESTERS_TO_COMPLETE)
        semestersCompleted = min(semestersCompleted, MAX_SEMESTERS_TO_COMPLETE)
        semesters = list(semesterData.keys())

        for _ in range(semestersCompleted):
            semesterKey = random.choice(semesters)
            semesterName, year = semesterKey.rsplit(' ', 1)
            subject = random.choice(list(semesterData[semesterKey].keys()))
            course = random.choice(semesterData[semesterKey][subject])
            section = random.choice(course["sections"])
            grade = round(random.uniform(2.6, 4.0), 1)

            takesQuery = f"INSERT INTO [dbo].[takes] ([studentID], [courseID], [sectionID], [semester], [year], [grade], [active]) VALUES ({student['studentID']}, '{course['courseID']}', '{section['sectionID']}', '{semesterName}', {year}, {grade}, 'Yes');"
            takesQueries.append(takesQuery)

    return takesQueries
# Main script
students = loadStudents(studentSQLFilePath)
takesQueries = generateTakesQueries(students, semesterData)

# Write the queries to the output file
with open(outputFilePath, 'w') as file:
    for query in takesQueries:
        file.write(query + "\n")

print(f"Generated 'takes' queries written to '{outputFilePath}'")