stu, ques = [int(i) for i in input().split()]
mistakes = [0] * ques
answers = []
for i in range(ques):
    n = input().split()
    answers.append(n)

stu_answers = []
for i in range(stu):
    m = input()[1:-1].split(') (')
    tmp = []
    for j in m:
        tmp.append(j.split())
    stu_answers.append(tmp)

for student in stu_answers:
    score = 0
    for i in range(ques):
        if student[i] == answers[i][2:]:
            score += int(answers[i][0])
        else:
            mistakes[i] += 1
    print(score)
maxx = max(mistakes)
if maxx == 0:
    print('Too simple')
else:
    print(maxx, end=' ')
    l = []
    for i in range(ques):
        if mistakes[i] == maxx:
            l.append(str(i + 1))
    print(' '.join(l))