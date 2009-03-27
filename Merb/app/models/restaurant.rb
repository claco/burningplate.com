require 'dm-timestamps'

class Restaurant
  include DataMapper::Resource
  
  property :id,   Serial
  property :name, String, :length => 255, :nullable => false
  property :created_at, DateTime
  property :updated_at, DateTime

end
