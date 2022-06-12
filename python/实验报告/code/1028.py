n = int(input())
count = 0
max_name = ''
min_name = ''
max_birth = '1814/09/06'
min_birth = '2014/09/06'
for i in range(n):
    person = input().split()
    if '1814/09/06' <= person[1] <= '2014/09/06':
        count += 1
        if person[1] > max_birth:
            max_name = person[0]
            max_birth = person[1]
        if person[1] < min_birth:
            min_name = person[0]
            min_birth = person[1]

if count:
    print(count, min_name, max_name)
else:
    print('0')