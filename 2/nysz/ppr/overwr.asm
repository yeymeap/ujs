
Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX

Input:
	mov ah, 2
	mov dl, 8h ; backspace
	;mov dl, 0dh ; carriage return
	int 21h
	
	mov ah, 0 ; beolvasás
	int 16h ; input figyelő megszakítás
	; a beolvasott karakter már  az al-ben szerepel
	
	mov ah, 2 ; karakter kiírás
	mov dl, al ; dl-be al értékét írja
	int 21h
	
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

