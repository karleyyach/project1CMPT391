import json
import os
import re

# Map courses to departments. thnx chat gpt :)
department_mapping = {
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

credit_pattern = re.compile(r'\s+\d+(\.\d+)?\s+Credits?\s+.*$', re.IGNORECASE)

def clean_course_title(title):
    clean_title = credit_pattern.sub('', title)
    return clean_title

# Read the JSON
file_path = os.path.join(os.getcwd(), 'all_courses.json')
with open(file_path, 'r', encoding='utf-8') as file:
    all_courses = json.load(file)

# Write the SQL query
output_sql_path = os.path.join(os.getcwd(), 'insert_statements.sql')
with open(output_sql_path, 'w', encoding='utf-8') as sql_file:
    # Iterate over all courses
    for subject, courses in all_courses.items():
        department_name = department_mapping.get(subject, "Unknown Department")
        for course in courses:
            course_id = course['courseID'].replace("'", "''")
            
            # Cleanup
            course_title = clean_course_title(course['courseTitle'].replace("'", "''"))
            
            sql_statement = f"INSERT INTO [dbo].[course] ([courseID], [courseName], [deptName]) " \
                            f"VALUES ('{course_id}', '{course_title}', '{department_name}');\n"
            sql_file.write(sql_statement)

print(f"Lets see how we did --> '{output_sql_path}'.")