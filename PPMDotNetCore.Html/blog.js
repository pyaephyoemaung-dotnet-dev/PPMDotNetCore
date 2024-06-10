const tblBlog = 'blogs';
let blogId = null;
// function running process

//createBlog();
getBlogTable();

// function running process end

// read process

function readBlog() {
  let lst = getBlog();
  console.log(lst);
}

// create process

function createBlog(title, author, content) {
  let lst = getBlog();

  const requestModel = {
    id: uuidv4(),
    title: title,
    author: author,
    content: content,
  };

  lst.push(requestModel);
  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem(tblBlog, jsonBlog);

  successMessage('Creating successful.');
  clearFormControls();
}

// edit process
function editBlog(id) {
  let lst = getBlog();
  const items = lst.filter((x) => x.id === id);
  console.log(items);
  console.log(items.length);
  if (items.length == 0) {
    errorMessage('No data found.');
    return;
  }
  let item = items[0];
  blogId = item.id;
  $('#txtTitle').val(item.title);
  $('#txtAuthor').val(item.author);
  $('#txtContent').val(item.content);
  $('#txtTitle').focus();
  getBlogTable();
}

// update process
function updateBlog(id, title, author, content) {
  let lst = getBlog();
  const item = lst.filter((x) => x.id === id);
  console.log(item);
  console.log(item.length);
  if (item.length == 0) {
    console.log('no data found.');
    return;
  }
  const items = items[0];
  items.title = title;
  items.author = author;
  items.content = content;

  const index = lst.findIndex((x) => x.id === id);
  lst[index] = items;
  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem(tblBlog, jsonBlog);
  successMessage('Updating success.');
}

//delete process

function deleteblog(id) {
  let result = confirm('Are you sure delete?');
  if (!result) return;
  let lst = getBlog();
  const item = lst.filter((x) => x.id === id);
  if (item.length == 0) {
    console.log('no data found.');
    return;
  }
  lst = lst.filter((x) => x.id !== id);
  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem(tblBlog, jsonBlog);
  successMessage('Deleting succeful.');
  getBlogTable();
}

// get blog process
function getBlog() {
  const blogs = localStorage.getItem(tblBlog);
  console.log(blogs);

  let lst = [];
  if (blogs !== null) {
    lst = JSON.parse(blogs);
  }
  return lst;
}

//clink event
$('#btnSave').click(function () {
  const title = $('#txtTitle').val();
  const author = $('#txtAuthor').val();
  const content = $('#txtContent').val();

  if (blogId === null) {
    createBlog(title, author, content);
  } else {
    updateBlog(blogId, title, author, content);
    blogId = null;
  }
  getBlogTable();
});

// data table
function getBlogTable() {
  const lst = getBlog();
  let count = 0;
  let htmlRows = '';
  lst.forEach((item) => {
    const htmlRow = `
    <tr class="border-b hover:bg-gray-100">
    <td>
      <button type="button" class="bg-yellow-300 text-white font-bold py-2 px-4 rounded" onclick="editBlog('${
        item.id
      }')">Edit</button>
      <button type="button" class="bg-rose-600 text-white font-bold py-2 px-4 rounded" onclick="deleteblog('${
        item.id
      }')">Delete</button>
    </td>
      <td class="py-3 px-4 text-center">${++count}</td>
      <td class="py-3 px-4 text-center">${item.title}</td>
      <td class="py-3 px-4 text-center">${item.author}</td>
      <td class="py-3 px-4 text-center">${item.content}</td>
    </tr>
    `;
    htmlRows += htmlRow;
  });
  $('#tbody').html(htmlRows);
}

// Message process
function successMessage(message) {
  alert(message);
}

function errorMessage(message) {
  alert(message);
}

// data clear proess

function clearFormControls() {
  $('#txtTitle').val('');
  $('#txtAuthor').val('');
  $('#txtContent').val('');
  $('#txtTitle').focus();
}

// auto generate id using uuid/guid
function uuidv4() {
  return '10000000-1000-4000-8000-100000000000'.replace(/[018]/g, (c) =>
    (
      +c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (+c / 4)))
    ).toString(16)
  );
}
