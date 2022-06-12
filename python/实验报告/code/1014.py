a, b, c, d = input(), input(), input(), input()
Ds = ['MON', 'TUE', 'WED', 'THU', 'FRI', 'SAT', 'SUN']
D = ''
H = ''
for i in range(min(len(a), len(b))):
    if D == '' and a[i].isupper() and a[i] == b[i] and a[i] in ['A', 'B', 'C', 'D', 'E', 'F', 'G']:
        D = a[i]
    elif D != '' and H == '' and a[i] == b[i]:
        if a[i] in [str(x) for x in range(10)] or a[i] in [chr(x) for x in range(65, 79)]:
            H = a[i]
            break
M = 0
for i in range(min(len(c), len(d))):
    if c[i] == d[i] and c[i].isalpha():
        M = i
        break
print('{} {:0>2}:{:0>2}'.format(Ds[ord(D) - ord('A')], ord(H) - ord('A') + 10 if H.isalpha() else H, M))