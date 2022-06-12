def fun1(a, b):
    '''a与b补齐,前面补"0"'''
    if len(a) > len(b):
        b = "0" * (len(a) - len(b)) + b
    else:
        a = "0" * (len(b) - len(a)) + a
    return a, b


def fun(a, b):
    '''
    遍历b,与对应a,
    奇数位相加对13取余,超出用J,Q,K,
    偶数用b减a结果为负再加10,
    返回列表
    '''
    result = []
    lst = ['0', '1', '2', '3', '4', '5', '6',
           '7', '8', '9', 'J', 'Q', 'K']
    for i in range(len(b)):
        if i % 2 == 0:
            result.append(lst[(int(b[i]) + int(a[i])) % 13])
        else:
            ans = int(b[i]) - int(a[i])
            if ans < 0:
                ans += 10
            result.append(str(ans))
    return result


a, b = input().split()
a, b = fun1(a, b)
a, b = list(reversed(a)), list(reversed(b))
print(*reversed(fun(a, b)), sep='')