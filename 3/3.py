import string

dict1 = dict(zip(string.ascii_lowercase, range(1,27)))
dict1.update(dict(zip(string.ascii_uppercase, range(27,53))))

file = open("input.txt", 'r')
lines = file.readlines()

priorityTotal = 0
for line in lines:
    compart1, compart2 = line[:len(line)//2], line[len(line)//2:]
    common = ''.join(set(compart1).intersection(compart2))
    priorityTotal += dict1.get(common)
print(priorityTotal)

badgeTotal = 0
for i in range(0, len(lines), 3):
    line1 = lines[i].replace('\n', '')
    line2 = lines[i + 1].replace('\n', '')
    line3 = lines[i + 2].replace('\n', '')

    badge = ''.join(set.intersection(*map(set, {line1, line2, line3})))
    badgeTotal += dict1.get(badge)
print(badgeTotal)




