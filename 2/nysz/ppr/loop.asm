
Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX

	; make bx zero
	xor bx, bx

Loop1:
	; compare
	cmp bl, 5
	; if true
	jz Program_Vege
	; if false, write out, increment
	mov ah, 2
	mov dl, bl
	add dl, 48
	int 21h
	mov dl, 10
	int 21h
	inc bl
	jmp Loop1
Program_Vege:
	mov	ax, 4c00h
	int	21h



Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start

