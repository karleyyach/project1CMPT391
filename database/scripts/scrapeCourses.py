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

def cleanCourseTitle(title):
    cleanTitle = creditPattern.sub('', title)
    return cleanTitle

# Format prerequisites
def formatPrerequisites(prerequisitesText):
    prerequisitesText = re.sub(r'\s+', ' ', prerequisitesText).strip()
    prerequisitesText = re.sub(r'[^\w\s,]', '', prerequisitesText)

    # Convert 'consent' to 'DEPT_CONSENT'
    prerequisitesText = re.sub(r'\bconsent\b', 'DEPT_CONSENT', prerequisitesText, flags=re.IGNORECASE)

    codeAndNumberRegex = r'\b([A-Z]{4})(?:\s+(\d{3}))?\b'

    parts = re.split(r'\s+or\s+', prerequisitesText, flags=re.IGNORECASE)

    newParts = []
    for part in parts:
        matches = re.findall(codeAndNumberRegex, part)
        if matches:
            reconstructedPart = ' && '.join(['{} {}'.format(m[0], m[1]).strip() for m in matches])
            reconstructedPart = re.sub(r'\b(and|&)\b', '&&', reconstructedPart, flags=re.IGNORECASE)
            reconstructedPart = reconstructedPart.replace(',', '&&')
            newParts.append(reconstructedPart)
    prerequisitesText = ' || '.join(newParts)

    prerequisitesText = re.sub(r'\s*&&\s*', ' && ', prerequisitesText)
    prerequisitesText = re.sub(r'\s*\|\|\s*', ' || ', prerequisitesText)

    prerequisitesText = '' if not prerequisitesText.strip() else prerequisitesText

    return prerequisitesText

# Scraping criteria
def scrapeCourseInfo(htmlContent):
    soup = BeautifulSoup(htmlContent, 'html.parser')
    courseBlocks = soup.find_all('div', class_='courseblock')
    courses = []

    for block in courseBlocks:
        titleBlock = block.find('p', class_='courseblocktitle')
        descBlock = block.find('p', class_='courseblockdesc')
        prereqBlock = block.find('p', class_='courseblockextra')  # prerequisites

        if titleBlock and descBlock:
            titleText = titleBlock.get_text(" ", strip=True)
            descText = descBlock.get_text(" ", strip=True)
            parts = titleText.split(' ', 1)
            if len(parts) >= 2:
                courseId = parts[0].strip()
                if len(parts) > 1:
                    courseTitle = cleanCourseTitle(parts[1])
                else:
                    courseTitle = "ERROR_UNKNOWN" # hope to god this doesnt happen
                prereqText = formatPrerequisites(prereqBlock.get_text(" ", strip=True)) if prereqBlock else ''
                courses.append({
                    'courseID': courseId,
                    'courseTitle': courseTitle,
                    'courseDesc': descText,
                    'coursePrereq': prereqText
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
