clear;clc;
data=load('data6.txt');
x=1:100;y=x;z=y;
v=zeros(100,100,100);
for i=1:length(data)
    c=floor(data(i)/10000)+1;
    a=floor((data(i)-(c-1)*10000)/100)+1;
    b=data(i)-(c-1)*10000-(a-1)*100+1;
    v(a,b,c)=v(a,b,c)+0.1;
    i
end
slice(v,x,y,z);
saveas(gcf,'6','fig');
% close all;