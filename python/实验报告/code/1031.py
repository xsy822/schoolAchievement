def fun(s):
    '''查验s身份证号码最后一位是否合法'''
    if len(s) != 18:
        return False
    w = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2]
    c = ['1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2']
    sum = 0
    for i in range(17):
        if s[i] in ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9']:
            sum += int(s[i]) * w[i]
        else:
            return False
    return c[sum % 11] == s[17]


n = int(input())
flag = False
for i in range(n):
    s = input()
    if not fun(s):
        print(s)
        flag = True
if not flag:
    print('All passed')