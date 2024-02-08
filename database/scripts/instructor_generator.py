def formatName(name):
    parts = name.split()
    return ' '.join(part.capitalize().replace("'", "''") for part in parts)  # might still need to replace ' '  with " " for names like O'Connor?

def processLine(line, currentDepartment):
    if line.strip().endswith(':'):
        currentDepartment = line.strip()[:-1]
        if currentDepartment != 'School of Social Work':
            currentDepartment = 'Department of ' + currentDepartment
        return None, None, currentDepartment, False
    elif line.strip().upper() == line.strip() and ',' not in line.strip():
        names = line.strip().title().split()
        if names:
            firstName, lastName = names[0], ' '.join(names[1:])
            firstName, lastName = formatName(firstName), formatName(lastName)
            return firstName, lastName, currentDepartment, False
    elif 'Department Chair' in line:
        return None, None, currentDepartment, True
    return None, None, currentDepartment, False

def main():
    instructorId = 1000  # Starting ID
    currentDepartment = ''
    departmentHead = 'No'
    
    with open('instructors_macewan.txt', 'r') as infile, open('instructor_data.sql', 'w') as outfile:
        for line in infile:
            firstName, lastName, currentDepartment, isDepartmentHead = processLine(line, currentDepartment)
            if firstName and lastName:
                departmentHead = 'Yes' if isDepartmentHead else 'No'
                query = f"INSERT INTO [dbo].[instructor] ([instructorID], [firstName], [lastName], [deptName], [departmentHead]) VALUES ({instructorId}, '{firstName}', '{lastName}', '{currentDepartment}', '{departmentHead}');\n"
                outfile.write(query)
                instructorId += 1

if __name__ == '__main__':
    main()
