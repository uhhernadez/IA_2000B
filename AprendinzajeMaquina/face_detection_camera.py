import cv2

vid = cv2.VideoCapture(1)

#face_cascade = cv2.CascadeClassifier('/models/haarcascade_frontalface_default.xml') 
face_cascade = cv2.CascadeClassifier('/models/haarcascade_frontalface_alt.xml') 
#face_cascade = cv2.CascadeClassifier('/models/haarcascade_frontalface_alt_tree.xml') 

while(True): 
    ret, frame = vid.read() 
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY) 

    faces = face_cascade.detectMultiScale(gray, 1.3, 5) 

    for (x,y,w,h) in faces:
        cv2.rectangle(frame, (x,y),(x+w,y+h),(255,255,0),2)  
        roi_gray = gray[y:y+h, x:x+w]  
    
    cv2.imshow('frame', frame) 

    if cv2.waitKey(1) & 0xFF == ord('q'): 
        break
  
vid.release() 
cv2.destroyAllWindows() 