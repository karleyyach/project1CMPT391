import json
import requests
import os
import re
from bs4 import BeautifulSoup

baseUrl = "https://calendar.macewan.ca/course-descriptions/"

subjects = [
    "ACCT", "ACUP", "AEPS", "AGAD", "ANTH", "ARTE", "ASTR", "BCSC", "BICM", "BIOL", 
    "BOTN", "BUSN", "CHEM", "CHIN", "CHME", "CLAS", "CMPT", "CMSK", "COMP", "COOP", 
    "CORR", "COSL", "CRWR", "CYCW", "DESN", "DMWP", "DSLC", "EASC", "ECCS", "ECDV", 
    "ECON", "ECRP", "EDUC", "ENCP", "ENGG", "ENGL", "ENPH", "ENVS", "EOPT", "ERDW", 
    "ESPL", "FNCE", "FOUN", "FREN", "GEND", "GENE", "GERM", "GREK", "HAPR", "HEED", 
    "HIST", "HLSC", "HLST", "HRMT", "HSAD", "HUMN", "INDG", "INFM", "INSE", "INSR", 
    "INTA", "INTB", "INTD", "JAPN", "LATN", "LEGL", "LING", "MARK", "MATH", "MGMT", 
    "MGTS", "MSYS", "MTST", "MUSC", "NEHI", "NURS", "OAAS", "OADM", "OALS", "OAMS", 
    "OCCH", "OOSC", "ORGA", "PABA", "PACT", "PBNS", "PEDS", "PERL", "PESS", "PHIL", 
    "PHSC", "PHSD", "PHYS", "PMGT", "PNRS", "POLS", "PREL", "PROW", "PSSC", "PSYC", 
    "SCIE", "SCMT", "SOCI", "SOST", "SOWK", "SPAN", "STAT", "SUST", "TAST", "THAR", 
    "THAS", "THPR", "TRVL", "URBW", "WINL", "WRIT", "ZOOL"
]

allCourses = {}

creditPattern = re.compile(r'\s+\d+(\.\d+)?\s+Credits?\s+.*$', re.IGNORECASE)

def clean_course_title(title):
    clean_title = creditPattern.sub('', title)
    return clean_title

# Format prereqs with reeeeeeeee
def formatPrereqs(prereqsText):
    prereqsText = re.sub(r'\s+', ' ', prereqsText).strip()
    prereqsText = re.sub(r'[^\w\s,]', '', prereqsText)

    # Convert 'consent' to 'DEPT_CONSENT'
    prereqsText = re.sub(r'\bconsent\b', 'DEPT_CONSENT', prereqsText, flags=re.IGNORECASE)

    codeAndNumberRegex = r'\b([A-Z]{4})(?:\s+(\d{3}))?\b'

    parts = re.split(r'\s+or\s+', prereqsText, flags=re.IGNORECASE)

    newParts = []
    for part in parts:
        matches = re.findall(codeAndNumberRegex, part)
        if matches:
            reconstructedPart = ' && '.join(['{} {}'.format(m[0], m[1]).strip() for m in matches])
            reconstructedPart = re.sub(r'\b(and|&)\b', '&&', reconstructedPart, flags=re.IGNORECASE)
            reconstructedPart = reconstructedPart.replace(',', '&&')
            newParts.append(reconstructedPart)
    prereqsText = ' || '.join(newParts)

    prereqsText = re.sub(r'\s*&&\s*', ' && ', prereqsText)
    prereqsText = re.sub(r'\s*\|\|\s*', ' || ', prereqsText)

    prereqsText = '' if not prereqsText.strip() else prereqsText

    return prereqsText


# Scraping criteria
def scrapeCourseInfo(html_content):
    soup = BeautifulSoup(html_content, 'html.parser')
    course_blocks = soup.find_all('div', class_='courseblock')
    courses = []

    for block in course_blocks:
        title_block = block.find('p', class_='courseblocktitle')
        desc_block = block.find('p', class_='courseblockdesc')
        prereq_block = block.find('p', class_='courseblockextra')  # prereqs

        if title_block and desc_block:
            title_text = title_block.get_text(" ", strip=True)
            desc_text = desc_block.get_text(" ", strip=True)
            parts = title_text.split(' ', 1)
            if len(parts) >= 2:
                course_id = parts[0].strip()
                if len(parts) > 1:
                    course_title = clean_course_title(parts[1])
                else:
                    course_title = "ERROR_UNKNOWN" # hope to god this doesnt happen
                prereq_text = formatPrereqs(prereq_block.get_text(" ", strip=True)) if prereq_block else ''
                courses.append({
                    'courseID': course_id,
                    'courseTitle': course_title,
                    'courseDesc': desc_text,
                    'coursePrereq': prereq_text
                })
    return courses

def attemptScrape(subject, urlVariant):
    url = f"{baseUrl}{urlVariant}/"
    try:
        response = requests.get(url)
        if response.status_code == 200:
            return scrapeCourseInfo(response.content)
        else:
            return None
    except Exception as e:
        print(f"Failed to scrape {subject} at {url}: {e}")
        return None

if __name__ == "__main__":
    allCourses = {}
    for subject in subjects:
        subjectCourses = attemptScrape(subject, subject.lower())
        if subjectCourses is None:
            subjectCourses = attemptScrape(subject, subject.upper())
        if subjectCourses is not None:
            allCourses[subject] = subjectCourses
            print(f"Scraped {subject}")

    # Save data to JSON
    outputDir = 'c:/Users/AKIMBO-MSI/Documents/School/Winter 2024/cmpt391/scraping/scripts/'
    
    if not os.path.exists(outputDir):
        os.makedirs(outputDir)
        
    outputFile = 'all_courses.json'
    outputPath = os.path.join(outputDir, outputFile)
    
    try:
        with open(outputPath, 'w', encoding='utf-8') as f:
            json.dump(allCourses, f, ensure_ascii=False, indent=4)
        print(f"Scraping complete! How'd it go? --> '{outputPath}'")
    except Exception as e:
        print(f"An error occurred while saving the file: {e}")

    
