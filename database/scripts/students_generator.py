from faker import Faker  # Fake mfs
import random

fake = Faker()

def generateStudents(numStudents, numGraduated):
    students = []
    # Graduated students
    for _ in range(numGraduated):
        studentId = fake.unique.random_int(min=1000, max=99999)
        firstName = fake.first_name()
        lastName = fake.last_name()
        credits = 120  # Graduated students have completed 120 credits
        students.append((studentId, firstName, lastName, credits))
    
    # Current students
    for _ in range(numStudents - numGraduated):
        studentId = fake.unique.random_int(min=1000, max=99999)
        firstName = fake.first_name()
        lastName = fake.last_name()
        credits = random.choice(range(0, 120, 3))  # Let's assume all courses are 3 creds, make them vary
        students.append((studentId, firstName, lastName, credits))
    return students

def saveToFile(data, filename):
    with open(filename, 'w') as file:
        for entry in data:
            # Query
            insertStatement = f"INSERT INTO student (studentID, firstName, lastName, creditsCompleted) VALUES ('{entry[0]}', '{entry[1]}', '{entry[2]}', {entry[3]});\n"
            file.write(insertStatement)

# Generate
studentsData = generateStudents(22341, 15736)  # Some randomish numbers for realism

saveToFile(studentsData, 'students_data.sql')
