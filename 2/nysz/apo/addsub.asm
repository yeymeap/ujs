
Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX

	; add op1, op2
	
	mov bl, 7
	add bl, 2
	;sub bl, 2
	
	add bl, 48 ; eltolás a kiíráshoz
	
	mov ah, 2
	mov dl, bl
	int 21h


Program_Vege:
	mov	ax, 4c00h
	int	21h



Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start

