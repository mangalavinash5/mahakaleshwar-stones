const fs = require('fs');

const productsFilePath = '/Users/avinashsmac/Desktop/Jaipur_mineral/wwwroot/data/products.json';
const products = JSON.parse(fs.readFileSync(productsFilePath, 'utf8'));

const newProducts = [
  {
    "id": 1,
    "name": "Agra Red Sandstone Tiles",
    "slug": "agra-red-sandstone-tiles",
    "categorySlug": "sandstone-tiles",
    "categoryName": "Sandstone Tiles",
    "description": "Agra Red Sandstone, famously used in the Agra Fort and Taj Mahal, is a robust and weather-resistant natural stone. Its deep red hue and smooth texture make it an excellent choice for exterior paving, cladding, and landscaping.",
    "shortDescription": "Classic deep red sandstone from Agra, known for its historic use and durability.",
    "images": ["https://images.unsplash.com/photo-1565182999561-18d7dc61c393?w=800&q=80"],
    "finishType": "Natural/Honed",
    "finishTypes": ["Natural", "Honed", "Sandblasted"],
    "size": "600x300mm",
    "sizes": ["300x300mm", "600x300mm", "600x600mm", "Custom"],
    "color": "Red",
    "thickness": "20-30mm",
    "applications": ["Paving", "Wall Cladding", "Monuments", "Flooring"],
    "moq": "50 sq.m",
    "exportDetails": "Carefully packed in sturdy wooden crates for safe global export.",
    "isFeatured": true,
    "tags": "agra red sandstone tiles historic monument paving"
  },
  {
    "id": 2,
    "name": "Beige Sandstone Slabs",
    "slug": "beige-sandstone-slabs",
    "categorySlug": "sandstone-slabs",
    "categoryName": "Sandstone Slabs",
    "description": "Premium Beige Sandstone slabs offer a warm, neutral color palette that seamlessly blends with both modern and traditional architectural styles. Its consistent tone and fine grain make it highly versatile for indoor and outdoor use.",
    "shortDescription": "Versatile and elegant beige sandstone slabs for a clean, neutral aesthetic.",
    "images": ["https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=800&q=80"],
    "finishType": "Polished/Natural",
    "finishTypes": ["Polished", "Natural", "Brushed"],
    "size": "1200x600mm",
    "sizes": ["600x600mm", "1200x600mm", "Custom"],
    "color": "Beige/Cream",
    "thickness": "20-40mm",
    "applications": ["Flooring", "Pool Surrounds", "Patios", "Countertops"],
    "moq": "40 sq.m",
    "exportDetails": "Available in full container loads with export-grade packaging.",
    "isFeatured": true,
    "tags": "beige sandstone slabs neutral elegant flooring"
  },
  {
    "id": 3,
    "name": "Agra Red Sandstone Pebbles",
    "slug": "agra-red-sandstone-pebbles",
    "categorySlug": "garden-stone",
    "categoryName": "Garden Stone",
    "description": "Smooth, naturally tumbled Agra Red Sandstone pebbles. These vibrant red pebbles add a striking contrast to gardens, pathways, and water features, bringing a touch of natural warmth to any landscape design.",
    "shortDescription": "Vibrant red tumbled sandstone pebbles for decorative landscaping.",
    "images": ["https://images.unsplash.com/photo-1597220004564-4feda7f8bdb9?w=800&q=80"],
    "finishType": "Tumbled",
    "finishTypes": ["Tumbled", "Natural"],
    "size": "20-40mm",
    "sizes": ["10-20mm", "20-40mm", "40-60mm"],
    "color": "Red",
    "thickness": "N/A",
    "applications": ["Garden Borders", "Pathways", "Planters", "Water Features"],
    "moq": "1000 kg",
    "exportDetails": "Packed in 20kg poly bags or 1-ton jumbo bags.",
    "isFeatured": false,
    "tags": "agra red sandstone pebbles decorative garden landscaping"
  },
  {
    "id": 4,
    "name": "Beige Sandstone Pebbles",
    "slug": "beige-sandstone-pebbles",
    "categorySlug": "garden-stone",
    "categoryName": "Garden Stone",
    "description": "Elegant Beige Sandstone pebbles, smoothly tumbled for a refined finish. Their soothing neutral tones are perfect for creating zen gardens, contemporary pathways, and highlighting architectural planting beds.",
    "shortDescription": "Smooth, neutral beige sandstone pebbles for elegant garden spaces.",
    "images": ["https://images.unsplash.com/photo-1416879595882-3373a0480b5b?w=800&q=80"],
    "finishType": "Tumbled",
    "finishTypes": ["Tumbled"],
    "size": "20-40mm",
    "sizes": ["20-40mm", "40-60mm"],
    "color": "Beige",
    "thickness": "N/A",
    "applications": ["Zen Gardens", "Pathways", "Mulch Alternative", "Interior Decor"],
    "moq": "1000 kg",
    "exportDetails": "Exported globally in bulk or retail-ready packaging.",
    "isFeatured": false,
    "tags": "beige sandstone pebbles neutral garden zen landscaping"
  },
  {
    "id": 5,
    "name": "Agra Red Mosaic Wall Cladding",
    "slug": "agra-red-mosaic-wall-cladding",
    "categorySlug": "wall-cladding",
    "categoryName": "Wall Cladding",
    "description": "Intricately crafted Agra Red Sandstone mosaic tiles for spectacular wall cladding. These interlocking panels offer a 3D textured surface that transforms any feature wall into a captivating focal point with rich crimson hues.",
    "shortDescription": "Textured red sandstone mosaic panels for striking feature walls.",
    "images": ["https://images.unsplash.com/photo-1565182999561-18d7dc61c393?w=800&q=80"],
    "finishType": "Split Face Mosaic",
    "finishTypes": ["Split Face", "3D Interlocking"],
    "size": "300x300mm (Sheet)",
    "sizes": ["150x600mm", "300x300mm"],
    "color": "Red/Terracotta",
    "thickness": "15-25mm",
    "applications": ["Feature Walls", "Exterior Facades", "Fireplace Surrounds", "Retail Interiors"],
    "moq": "20 sq.m",
    "exportDetails": "Securely packed in carton boxes and wooden pallets to prevent damage.",
    "isFeatured": true,
    "tags": "agra red mosaic wall cladding 3d feature wall"
  },
  {
    "id": 6,
    "name": "Beige Sandstone Mosaic Cladding",
    "slug": "beige-sandstone-mosaic-cladding",
    "categorySlug": "wall-cladding",
    "categoryName": "Wall Cladding",
    "description": "Beautiful Beige Sandstone mosaic wall cladding that brings subtle texture and brightness to your walls. The split-face finish emphasizes the natural grain and variations of the stone, perfect for modern and rustic designs alike.",
    "shortDescription": "Elegant beige sandstone mosaic tiles for textured wall cladding.",
    "images": ["https://images.unsplash.com/photo-1600585154340-be6161a56a0c?w=800&q=80"],
    "finishType": "Split Face Mosaic",
    "finishTypes": ["Split Face", "Textured"],
    "size": "300x300mm (Sheet)",
    "sizes": ["150x600mm", "300x300mm"],
    "color": "Beige/Cream",
    "thickness": "15-25mm",
    "applications": ["Interior Feature Walls", "Facades", "Bathroom Accent Walls", "Commercial Foyers"],
    "moq": "20 sq.m",
    "exportDetails": "Carton packed and palletized for secure international shipping.",
    "isFeatured": true,
    "tags": "beige sandstone mosaic wall cladding textured natural"
  }
];

const combined = [...newProducts, ...products];

// Update IDs sequentially
combined.forEach((product, index) => {
  product.id = index + 1;
});

fs.writeFileSync(productsFilePath, JSON.stringify(combined, null, 2));
console.log('Updated products.json successfully.');
