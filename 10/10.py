X = 1
cycleCount = 0
sigStrength = 0
crtRows = ""

def addx(V):
    global cycleCount
    global X
    global crtRows
    global sigStrength

    for x in range(0, 2):
        if (drawable(cycleNo=cycleCount, xPos=X)):
            crtRows += "#"
        else:
            crtRows += "."
        cycleCount += 1
        if ((cycleCount - 20) % 40 == 0 or cycleCount == 20):
            sigStrength += (X * cycleCount)

    X += V

def noop():
    global cycleCount
    global crtRows

    if (drawable(cycleNo=cycleCount, xPos=X)):
        crtRows += "#"
    else:
        crtRows += "."
    cycleCount += 1
    if ((cycleCount - 20) % 40 == 0 or cycleCount == 20):
        global sigStrength
        sigStrength += (X * cycleCount)


def drawable(cycleNo, xPos):
    if (xPos - 1 == (cycleNo % 40) or xPos == (cycleNo % 40) or xPos + 1 == (cycleNo % 40)):
        return True
    return False
        

file = open("input.txt")
lines = file.readlines()

for line in lines:
    instructions = line.split(" ")
    match instructions[0]:
        case "addx":
            addx(int(instructions[1]))
        case "noop":
            noop()
        case "noop\n":
            noop()

print("Number of cycles: ", cycleCount)
print("Total signal strength: ", sigStrength)

for i in range(0, len(crtRows), 40):
    print(crtRows[i: i + 40])