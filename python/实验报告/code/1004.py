n = int(input())
students = []
for i in range(n):
    students.append(input().split(' '))
students.sort(reverse=True, key=lambda x: int(x[-1]))
print("{} {}".format(students[0][0], students[0][1]))
print("{} {}".format(students[-1][0], students[-1][1]))