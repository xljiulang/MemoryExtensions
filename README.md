## MemoryExtensions 　
High performance buffer types such as ArrayPool,IArrayOwner<T>,BufferWriter<T>,and Slice extension for IMemoryOwner<T>
```
<PackageReference Include="MemoryExtensions" Version="1.0.0" />
```
### ArrayPool

```
var arrayOwner = ArrayPool.Rent<byte>(10);
for (var i = 0; i < arrayOwner.Length; i++)
{
    arrayOwner.Array[i] = (byte)i;
}

// return the array to pool
arrayOwner.Dispose();
```
 
### BufferWriter

```
var writer = new BufferWriter<byte>(4);
writer.Write((byte)1);
writer.Write(new byte[] { 2, 3, 4 });
writer.WriteBigEndian(int.MaxValue);           
var writtern = writer.GetWrittenSpan(); // 1,2,3,4,127,255,255,255

// return the buffer to pool
writer.Dispose();
``` 

### BufferReader
```
var array = new byte[16];

var writer = array.CreateBufferWriter();
writer.WriteBigEndian(18);
writer.WriteBigEndian(2.01f);

var reader = new BufferReader(array);
reader.ReadBigEndian(out int v1);
reader.ReadBigEndian(out float v2);
```
    
### IMemoryOwner Slice 
```
var owner = MemoryPool<byte>.Shared.Rent(10);
new byte[] { 1, 2, 3, 4 }.CopyTo(owner.Memory.Span);
var sliced = owner.Slice(0, 2); // 1,2

// return the memory to pool
sliced.Dispose();
```