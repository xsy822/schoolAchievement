def funC(s: str) -> str:
    '''返回压缩字符串'''
    s = s+' '
    now = s[0]
    times = 0
    ans = ''
    for i in s:
        if i == now:
            times += 1
        else:
            if times == 1:
                ans += now
            else:
                ans += str(times)+now
            now = i
            times = 1
    return ans


def funD(s: str) -> str:
    '''返回解压字符串'''
    ans = ''
    i = 0
    while i < len(s):
        if s[i].isdigit():
            times = int(s[i])
            j = i+1
            while s[j].isdigit():
                times = times*10+int(s[j])
                j += 1
                i += 1
            i += 1
            ans += s[i]*times
            i += 1
        else:
            ans += s[i]
            i += 1
    return ans


op = input()
s = input()
if op == 'C':
    print(funC(s))
elif op == 'D':
    print(funD(s))