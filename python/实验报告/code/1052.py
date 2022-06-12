import sys
l = []
for i in range(3):
    try:
        data = sys.stdin.buffer.readline()
    except:
        while True:
            a = 1
    d = []
    s = bytes()
    for j in range(len(data)-1):
        if data[j:j+1] == b'[':
            s = bytes()
            continue
        if data[j:j+1] == b']':
            d.append(s)
            continue
        s += data[j:j+1]
    l.append(d)

k = int(input())

for i in range(k):
    num = []
    try:
        for j in input().split():
            j = int(j)-1
            if j < 0:
                raise
            num.append(j)
        if len(num) != 5:
            raise Exception()
        result = l[0][num[0]]+b'('+l[1][num[1]]+l[2][num[2]] + \
            l[1][num[3]]+b')'+l[0][num[4]]+b'\n'
    except Exception:
        result = b'Are you kidding me? @\/@\n'
    sys.stdout.buffer.write(result)