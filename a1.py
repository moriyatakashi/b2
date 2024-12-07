import clr
clr.AddReference("/myrpa/a2/b1.dll")
from A1 import A1
from b1 import b1
b1.progLines=["A START"," OUT B,C"," RET","B DC 65","C DC 1"," END"]
pl = A1.parseLine(b1.progLines[0])
print(pl.label)
print(pl.inst)
for i in pl.operands:
	print(i)