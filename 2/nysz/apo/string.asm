
Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX

	mov ah, 9 ; string kiiratás
	mov dx, offset msg
	int 21h
Program_Vege:
	mov	ax, 4c00h
	int	21h

msg db "Hello World!$"

Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start
