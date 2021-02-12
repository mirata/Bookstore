# BookStore

## Assumptions
Rather than overengineering this solution, I have opted to keep it simple. No databases or services, just an in-mem repository.

Building the order looks up the book and puts it in a model. If the book doesn't exist, it will throw an exception.

Rounded to the nearest 1c instead of 5c because there were items ending in .99

GST gets applied to the end of an order, since delivery is technically a service.
