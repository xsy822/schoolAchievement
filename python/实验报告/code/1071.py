T, K = map(int, input().split())
for i in range(K):
    n1, b, t, n2 = map(int, input().split())
    if t > T:
        print('Not enough tokens.  Total = {}.'.format(T))
        continue
    if (n1 < n2) == b:
        T += t
        print('Win {}!  Total = {}.'.format(t, T))
    else:
        T -= t
        print('Lose {}.  Total = {}.'.format(t, T))
        if T <= 0:
            print('Game Over.')
            break