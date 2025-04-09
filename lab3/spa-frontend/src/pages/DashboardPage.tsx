import React, { useState, useEffect } from 'react';
import axiosInstance from '../axiosConfig'; 

export default function BookPage() {
  const [books, setBooks] = useState<any[]>([]);
  const [page, setPage] = useState(1);
  const [sortBy, setSortBy] = useState("title");
  const [totalPages, setTotalPages] = useState(1);
  const [error, setError] = useState<string | null>(null); 
  const [loading, setLoading] = useState<boolean>(false); 

  const fetchBooks = async () => {
    setLoading(true);
    setError(null); 
    try {
      const response = await axiosInstance.get('/books', {
        params: { page, pageSize: 5, sortBy }
      });

      if (response.data.books.length === 0) {
        setError('No books found.');
      } else {
        setBooks(response.data.books);
        setTotalPages(response.data.totalPages);
      }
    } catch (err) {
      setError('An error occurred while fetching the books. Please try again later.');
      console.error('Error fetching books:', err);
    } finally {
      setLoading(false); 
    }
  };

  useEffect(() => {
    fetchBooks();
  }, [page, sortBy]);

  const handleSort = (column: string) => {
    setSortBy(column);
    setPage(1); 
  };

  const handlePageChange = (newPage: number) => {
    setPage(newPage);
  };

  return (
    <div>
      <h1>Books List</h1>
      <button onClick={() => handleSort('title')}>Sort by Title</button>
      <button onClick={() => handleSort('id')}>Sort by ID</button>
      <button onClick={() => handleSort('author')}>Sort by Author</button>
      {loading && <p>Loading...</p>}
      {error && <p style={{ color: 'red' }}>{error}</p>}
      
      {!loading && !error && books.length > 0 && (
        <table>
          <thead>
            <tr>
              <th>Title</th>
              <th>Author</th>
              <th>Reviews</th>
            </tr>
          </thead>
          <tbody>
            {books.map((book: any) => (
              <tr key={book.id}>
                <td>{book.title}</td>
                <td>{book.author?.name}</td>
                <td>{book.reviews?.length}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}

      {!loading && !error && books.length > 0 && (
        <div>
          <button onClick={() => handlePageChange(page - 1)} disabled={page === 1}>
            Previous
          </button>
          <span>Page {page} of {totalPages}</span>
          <button onClick={() => handlePageChange(page + 1)} disabled={page === totalPages}>
            Next
          </button>
        </div>
      )}

      {!loading && !error && books.length === 0 && (
        <p>No books available.</p>
      )}
    </div>
  );
}
