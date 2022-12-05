import string

def calculate(move1, move2):
    resultScore = 0
    if (draw(move1=move1, move2=move2)):
        resultScore = 3
    elif(win(move1=move1, move2=move2)):
        resultScore = 6
    return scores.get(move2) + resultScore

def calculate2(move1, move2):
    outcomeScore = 0
    if (move2 == 'X'):
        outcomeScore = 0 + toLose.get(move1)
    elif (move2 == 'Y'):
        outcomeScore = 3 + scores.get(move1)
    elif (move2 == 'Z'):
        outcomeScore = 6 + toWin.get(move1)
    return outcomeScore

def draw(move1, move2):
    if (ord(move2) - ord(move1) == 23):
        return True
    return False

def win(move1, move2):
    if ((move1 == 'A' and move2 == 'Y')
        or (move1 == 'B' and move2 == 'Z')
        or (move1 == 'C' and move2 == 'X')):
        return True
    return False    


file = open("input.txt", 'r')
lines = file.readlines()

scores = dict()
scores['A'] = 1
scores['B'] = 2
scores['C'] = 3
scores['X'] = 1
scores['Y'] = 2
scores['Z'] = 3

toWin = dict()
toWin['A'] = 2
toWin['B'] = 3
toWin['C'] = 1

toLose = dict()
toLose['A'] = 3
toLose['B'] = 1
toLose['C'] = 2

score = 0
score2 = 0

for line in lines:
    moves = list(line)
    score += calculate(moves[0], moves[2])
    score2 += calculate2(moves[0], moves[2])
    
print(score)
print(score2)