def fun(scores):
    '''去掉一个最高分,一个最低分'''
    scores.sort()
    scores.pop(0)
    scores.pop(-1)
    return scores


N, M = map(int, input().split())
for _ in range(N):
    scores = list(filter(lambda x: 0 <= x <= M,
                         list(map(int, input().split()))))
    t, scores = scores[0], scores[1:]
    G2 = sum(fun(scores))/len(scores)
    G1 = t
    print(int((G1+G2)/2+0.5))