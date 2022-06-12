M, N, S = [int(i) for i in input().split()]
persons = [input() for i in range(M)]
picked = {}
try:
    picked[persons[S-1]] = 1
    for i in range(S, M+1):
        if i-S == N:
            if persons[i-1] not in picked:
                picked[persons[i-1]] = 1
                S = i
            else:
                S += 1
except:
    print('Keep going...')
    exit()
if len(picked):
    print(*picked.keys(), sep='\n')
else:
    print('Keep going...')