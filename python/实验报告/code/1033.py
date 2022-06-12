wrong = input()
cin = input()
daxie = [chr(i) for i in range(65, 91)]
if '+' in wrong:
    print(*list(filter(lambda x: not(x.upper() in wrong or x in daxie), cin)),sep='')
else:
    print(*list(filter(lambda x: x.upper() not in wrong, cin)), sep='')