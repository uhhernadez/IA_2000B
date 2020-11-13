import tensorflow.keras
from PIL import Image, ImageOps
import numpy as np

# Disable scientific notation for clarity
np.set_printoptions(suppress=True)

# Load the model
model = tensorflow.keras.models.load_model('models/keras/01/keras_model.h5')

data = np.ndarray(shape=(1, 224, 224, 3), dtype=np.float32)

image = Image.open('test_photo.jpg')

size = (224, 224)
image = ImageOps.fit(image, size, Image.ANTIALIAS)

image_array = np.asarray(image)

image.show()

normalized_image_array = (image_array.astype(np.float32) / 127.0) - 1

data[0] = normalized_image_array

prediction = model.predict(data)
print(prediction)