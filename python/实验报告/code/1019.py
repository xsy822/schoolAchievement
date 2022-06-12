n = input()
while 1314520:
    n = ''.join(sorted(list(n.zfill(4))))
    print('{} - {} = {}'.format(n[::-1],n , str(int(n[::-1]) -int(n) ).zfill(4)))
    n = str(int(n[::-1]) -int(n) ).zfill(4)
    if n in ('6174', '0000'):
        break