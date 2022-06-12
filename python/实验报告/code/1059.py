n = int(input())
winners_dict = dict()
for i in range(n):
    winners_dict[input()] = i + 1

prime = set()
if n < 10:
    n = 10
flag = [1] * (n + 2)
p = 2
while p <= n:
    prime.add(p)
    for i in range(2 * p, n + 1, p):
        flag[i] = 0
    while 1:
        p += 1
        if flag[p] == 1:
            break

m = int(input())
for i in range(m):
    my_id = input()
    if my_id in winners_dict.keys():
        x = winners_dict[my_id]
        winners_dict[my_id] = -1
        if x == -1:
            print('{}: Checked'.format(my_id))
        elif x == 1:
            print('{}: Mystery Award'.format(my_id))
        elif x in prime:
            print('{}: Minion'.format(my_id))
        else:
            print('{}: Chocolate'.format(my_id))
    else:
        print('{}: Are you kidding?'.format(my_id))