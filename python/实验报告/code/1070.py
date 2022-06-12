input()
result, *l = sorted([int(x) for x in input().split()])
for i in l:
    result = (result+i)/2
print(int(result))