#version 330

out vec4 outputColor;

//terima dari step sebelumnya yaitu .vert
//in vec4 vertexcolor;

uniform vec3 color;

void main(){
	outputColor = vec4(color,1.0);
//	outputColor = vertexcolor;
}

//#version 330
//
//out vec4 outputColor;
//
//
//uniform vec3 ourColor;
//
//void main(){
//	outputColor = vec4(ourColor,1.0);
//}