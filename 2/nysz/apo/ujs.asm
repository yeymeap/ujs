
Code	Segment
	assume CS:Code, DS:Data, SS:Stack

Start:
	mov	ax, Code
	mov	DS, AX

	mov ah, 9
	mov dx, offset msg
	int 21h
	
	mov ah, 2
	mov dl, 10
	int 21h
	mov dl, 54h
	int 21h
	mov dl, 4bh
	int 21h
	mov dl, 4bh
	int 21h
	
	mov dl, 10
	int 21h
	mov dl, 82
	int 21h
	mov dl, 84
	int 21h
	mov dl, 75
	int 21h
	
	mov dl, 10
	int 21h
	mov dl, "G"
	int 21h
	mov dl, "I"
	int 21h
	mov dl, "K"
	int 21h
	
Program_Vege:
	mov	ax, 4c00h
	int	21h

msg db "UJS$"

;UJS - string
;TKK - hex char
;RTK - dec char
;GIK - "" char 

Code	Ends

Data	Segment

Data	Ends

Stack	Segment

Stack	Ends
	End	Start
