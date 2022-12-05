maxCal = 0
currTotal = 0
file = open("input.txt", 'r')
Lines = file.readlines()
totals = []

for line in Lines:
    if (line == '\n'):
        if (currTotal > maxCal):
            maxCal = currTotal
        totals.append(currTotal)
        currTotal = 0
    else:
        currTotal += int(line)
    
print(maxCal)
totals.sort(reverse=True)
print(totals[0] + totals[1] + totals[2])