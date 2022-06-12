pw, times = input().split()
times = int(times)
for i in range(times):
    p = input()
    if p == pw:
        print('Welcome in')
        exit()
    elif p == '#':
        exit()
    print('Wrong password: {}'.format(p))

print('Account locked')