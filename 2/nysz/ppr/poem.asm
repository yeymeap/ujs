
Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX

	mov ah, 9
	mov dx, offset msg
	int 21h
		
Program_Vege:
	mov	ax, 4c00h
	int	21h

msg db "To see a World in a Grain of Sand", 13, 10, "And a Heaven in a Wild Flower,", 13, 10, "Hold Infinity in the palm of your hand", 13, 10, "And Eternity in an hour.", "$"

Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start
