N, M = map(int, input().split())
scores = [int(i) for i in input().split()]
answers = [int(i) for i in input().split()]
for i in range(N):
    stu_answe = [int(i) for i in input().split()]
    score = 0
    for j in range(M):
        score += scores[j] if (answers[j] == stu_answe[j]) else 0
    print(score)