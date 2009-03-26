class Restaurant
  include DataMapper::Resource
  
  property :id,   Serial
  property :name, String, :length => 255, :nullable => false
  property :created, DateTime, :nullable => false, :default => Proc.new { |r, p| DateTime.now }
  property :updated, DateTime, :nullable => false, :default => Proc.new { |r, p| DateTime.now }

end
