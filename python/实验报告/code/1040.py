n = input()
count_P = count_PA = count_PAT = 0
for i in n:
    if 'P' == i:
        count_P += 1
    elif 'A' == i:
        count_PA += count_P
    else:
        count_PAT += count_PA
print(count_PAT % 1000000007)