n = input()
for i in range(10):
    if n == n[::-1]:
        print('{} is a palindromic number.'.format(n))
        exit()
    new = str(int(n)+int(n[::-1]))
    print('{} + {} = {}'.format(n, n[::-1], new))
    n = new
print('Not found in 10 iterations.')