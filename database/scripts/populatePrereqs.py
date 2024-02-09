import json
import os
import re

def generateSqlForPrereqs(allCourses):
    sqlStatements = []
    coursePattern = re.compile(r'^[A-Z]{4}\s+\d{3}$') # not doing ANY courses for now

    for subject, courses in allCourses.items():
        for course in courses:
            courseId = course['courseID'].replace("'", "''").strip()
            if coursePattern.match(courseId):
                prereqs = [prereq.strip() for prereq in re.split(r'\s*(&&|\|\|)\s*', course['coursePrereq']) if prereq and prereq not in ['&&', '||'] and coursePattern.match(prereq)]
                
                for prereq in prereqs:
                    prereqId = prereq.replace("'", "''").strip()
                    sqlStatement = f"INSERT INTO [dbo].[prereq] ([courseID], [prereqID]) VALUES ('{courseId}', '{prereqId}');"
                    sqlStatements.append(sqlStatement)
    
    return sqlStatements

filePath = 'c:/Users/AKIMBO-MSI/Documents/School/Winter 2024/cmpt391/scraping/scripts/all_courses.json'
with open(filePath, 'r', encoding='utf-8') as file:
    allCourses = json.load(file)

sqlStatements = generateSqlForPrereqs(allCourses)

outputSqlPath = os.path.join(os.getcwd(), 'prereq_data.sql')
with open(outputSqlPath, 'w', encoding='utf-8') as sqlFile:
    for statement in sqlStatements:
        sqlFile.write(statement + '\n')

print(f"SQL statements --> '{outputSqlPath}'.")
