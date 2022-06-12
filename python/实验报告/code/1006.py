n = int(input())
B, S, Y = n//100, n % 100//10, n % 10
print('{}{}{}'.format('B'*B, 'S'*S,
                      ''.join([str(i) for i in range(1, Y+1)])))