i=10;
print(i)
print('-----------------')

if i==9 :
    print(i)
if i==8:
    print(i)
else :
    print('else')
print('-----------------')

print(2**5)
print(17//2)
print ('I\'am' + 3 * ' very' + ' hungry.')
print('-----------------')

str = 'Python'
print(str[0:6])
print(str[0:2])
print('-----------------')

str = 'iPhone is a good product.'
print(str[:6])   #從頭開始到第6個切片
print(str[2:])   #第2個切片開始到字串尾端『str[2:]』
print('-----------------')

# switch -case
def f(x):
    return{
        'a':1,
        'b':2,
    }[x]
print(f('a'))
print('-----------------')

#for loop
for i in range(10):
    print(i)

for ii in range(0,30,5):
    print(ii)
print('-----------------')

#while loop
i=0
while i<5:
    print(i)
    i+=1

print('-----------------')

my_list = [1,2,3,4,5,6,7,8,9,9,9,10,100]
print(my_list)
print('-----------------')

my_list.append(100)
print(my_list)

my_list[len(my_list):]=[9]
print(my_list)

your_list = [0,0,0,0]
#用這種方式加入，會一個個元素加入
my_list[len(my_list):]=your_list
print(my_list)

#用這種方式加入，會當做一個元素加入
my_list.append(your_list);
print(my_list)
print('-----------------')

my_list.insert(1,1000)
print(my_list)
print('-----------------')

my_list.remove(2)
print(my_list)
print('-----------------')


print('-----------------')
print('-----------------')
print('-----------------')
print('-----------------')
print('-----------------')
print('-----------------')
print('-----------------')
print('-----------------')
print('-----------------')
print('-----------------')
print('-----------------')
print('-----------------')
print('-----------------')
print('-----------------')
print('-----------------')