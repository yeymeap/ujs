
Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX

Input:	
	; read input character
	mov ah, 0
	int 16h
	
	; write out character
	mov ah, 2
	mov dl, al
	int 21h
	
	; compare input
	cmp dl, 'Q'
	
	; end if true
	jz Program_Vege
	
	; continue if false
	jmp Input

Program_Vege:
	mov	ax, 4c00h
	int	21h



Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start

